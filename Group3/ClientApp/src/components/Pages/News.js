﻿import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import { Calendar, DateRangePicker } from 'react-date-range';
import 'react-date-range/dist/styles.css'; // main style file
import 'react-date-range/dist/theme/default.css'; // theme css file
import { addDays, format, isWeekend } from 'date-fns';

function getSunday(d) {
    d = new Date(d);
    var day = d.getDay(),
        diff = d.getDate() - day + (day == 0 ? -6 : 0); // adjust when day is sunday
    return new Date(d.setDate(diff));
}

function getSaturday() {
    var now = new Date();
    var sunday = new Date(now.getFullYear(), now.getMonth(), now.getDate() + (6 - now.getDay()));
    return sunday;
}


export default function News() {
    const authContext = useContext(AuthContext);
    const [newsCategory, setNewsCategory] = useState(null);
    const [eventsTopic, setEventsTopic] = useState(null);
    const [selectedPost, setSelectedPost] = useState([]);

    const [state, setState] = useState({
        selection: {
            startDate: getSunday(new Date()),
            endDate: getSaturday(),
            key: 'selection'
        }
    });

    const updateNews = async () => {
        API.getNews().then((newsCategory) => {
            setNewsCategory(newsCategory);
            setEventsTopic(newsCategory.Topics.find(x => x.Name == "Events"));
        });
    }

    useEffect(() => {
        updateNews();
    }, [])

    const handleSelect = (item) => {
        setState({ ...state, ...item });

        API.getPostsByDate({
            startDate: format(item.selection.startDate, "yyyy-MM-dd"),
            endDate: format(item.selection.endDate, "yyyy-MM-dd"),
        }).then((posts) => {
            setSelectedPost(posts);
            console.log(posts);
        });
    }
    
    const customDayContent = (day) =>  {
        return (
            <div>
                {newsCategory?.PostDates?.map(x => (format(Date.parse(x), "yyyy-MM-dd"))).includes(format(day, "yyyy-MM-dd")) &&
                    <div className="news-dot bg-danger" />
                }
                {eventsTopic?.PostDates?.map(x => (format(Date.parse(x), "yyyy-MM-dd"))).includes(format(day, "yyyy-MM-dd")) &&
                    <div className="event-dot bg-success" />
                }
                <span>{format(day, "d")}</span>
            </div>
        )
    }

    return (
        <div>
            <DateRangePicker
                onChange={handleSelect}
                months={1}
                minDate={addDays(new Date(), -365)}
                maxDate={addDays(new Date(), 365)}
                direction="vertical"
                ranges={[state.selection]}
                dayContentRenderer={customDayContent}
            />
        </div>
    );
}