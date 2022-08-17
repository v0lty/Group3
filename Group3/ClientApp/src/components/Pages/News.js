import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import Category from './Category';
import { Calendar, DateRangePicker } from 'react-date-range';
import 'react-date-range/dist/styles.css'; // main style file
import 'react-date-range/dist/theme/default.css'; // theme css file
import { addDays, format, isWeekend } from 'date-fns';

export default function News() {
    const authContext = useContext(AuthContext);
    const [newsCategory, setNewsCategory] = useState(null);

    const [state, setState] = useState({
        selection: {
            startDate: new Date(),
            endDate: addDays(new Date(), 2),
            key: 'selection'
        }
    });

    const updateNews = async () => {
        API.getNews().then((newsCategory) => {
            setNewsCategory(newsCategory);
        });
    }

    useEffect(() => {
        updateNews();
    }, [])

    const handleSelect = (item) => {
        setState({ ...state, ...item });

        console.log(format(item.selection.startDate, "yyyy-MM-dd") + " > " + format(item.selection.endDate, "yyyy-MM-dd"));
    }
    
    const customDayContent = (day) =>  {
        return (
            <div>
                {newsCategory?.PostDates?.map(x => (format(Date.parse(x), "yyyy-MM-dd"))).includes(format(day, "yyyy-MM-dd")) &&
                    <div className="calendnar-dot bg-danger" />
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
            <Category category={newsCategory} onUpdate={updateNews} />
        </div>
    );
}