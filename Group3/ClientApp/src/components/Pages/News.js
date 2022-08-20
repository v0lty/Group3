import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import { Calendar, DateRangePicker } from 'react-date-range';
import 'react-date-range/dist/styles.css'; // main style file
import 'react-date-range/dist/theme/default.css'; // theme css file
import { addDays, format, isWeekend } from 'date-fns';
import { enGB } from 'date-fns/locale'
import moment from "moment";

export default function News() {
    const authContext = useContext(AuthContext);
    const [newsCategory, setNewsCategory] = useState(null);
    const [eventsTopic, setEventsTopic] = useState(null);
    const [selectedPost, setSelectedPost] = useState([]);

    const [state, setState] = useState({
        selection: {
            startDate: new Date(new Date().getFullYear(), new Date().getMonth(), 1),
            endDate: new Date(),
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
            endDate: format(addDays(item.selection.endDate, 1), "yyyy-MM-dd"),
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
                className="w-100 mb-3"
                locale={enGB}
                weekStartsOn={1}
                showDateDisplay={false}
                onChange={handleSelect}
                months={1}
                minDate={addDays(new Date(), -365)}
                maxDate={addDays(new Date(), 365)}
                direction="vertical"
                ranges={[state.selection]}
                dayContentRenderer={customDayContent}
            />
            {selectedPost?.map((post, postIndex) =>
                <div className="border-top p-3">
                    <h4>{moment(post.EventDate != null ? post.EventDate : post.Time).format('YYYY/MM/DD')}</h4>
                    <div className="row p-3 ">
                        <div className="col-1" style={{ minWidth: 175 }}>                      
                            <div className="row m-0">
                                <img className="profile-picture pb-2" src={`../Pictures/${post?.Aurthor.ProfilePicture?.Path}`}></img>
                            </div>
                            <div className="row m-0">
                                <h5>{post.Aurthor?.Name}</h5>
                                <span className="text-muted">
                                    <b className="text-info">{post.Aurthor?.RoleString}</b><br />
                                    <b>{moment().diff(post.Aurthor?.Birthdate, 'years')}</b> years old<br />
                                    from <b>{post.Aurthor?.Location}</b><br />
                                    with <b className="text-danger">{post.Aurthor?.PostsCount}</b> posts.<br />                               
                                </span>
                            </div>
                        </div>
                        <div className="col" style={{ minWidth: 250 }, { minHeight: 100 }}>
                            
                            <div className="bubble h-100 w-100 p-3">
                                <h4>{post.Subject.Name}</h4>
                                <div dangerouslySetInnerHTML={{ __html: post.Text }} />                         
                            </div>
                        </div>                        
                    </div>
                </div>

            )}
        </div>
    );
}