import React, { useState, useContext, useEffect } from 'react';
import { AuthContext } from "../UserAuthentication";
import API from "../API";
import { Calendar, DateRangePicker } from 'react-date-range';
import 'react-date-range/dist/styles.css'; 
import 'react-date-range/dist/theme/default.css'; 
import { addDays, addHours, format, isWeekend } from 'date-fns';
import { enGB } from 'date-fns/locale'
import moment from "moment";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faNewspaper, faCalendar, faLocationArrow } from '@fortawesome/free-solid-svg-icons'
import { useHistory } from "react-router-dom";

export default function News() {
    const authContext = useContext(AuthContext);
    const [newsCategory, setNewsCategory] = useState(null);
    const [eventsTopic, setEventsTopic] = useState(null);
    const [selectedPost, setSelectedPost] = useState([]);
    const history = useHistory();

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

            API.getPostsByDate({
                startDate: format(state.selection.startDate, "yyyy-MM-dd HH:mm"),
                endDate: format(addHours(item.selection.endDate, 23), "yyyy-MM-dd HH:mm"),
            }).then((posts) => {
                setSelectedPost(posts);
                console.log(posts);
            });
        });
    }

    useEffect(() => {
        updateNews();
    }, [])

    const handleSelect = (item) => {
        setState({ ...state, ...item });

        API.getPostsByDate({
            startDate: format(item.selection.startDate, "yyyy-MM-dd HH:mm"),
            endDate: format(addHours(item.selection.endDate, 23), "yyyy-MM-dd HH:mm"),
        }).then((posts) => {
            setSelectedPost(posts);
        });
    }
    
    const customDayContent = (day) =>  {
        return (
            <div>
                {newsCategory?.PostDates?.map(x => (format(Date.parse(x), "yyyy-MM-dd"))).includes(format(day, "yyyy-MM-dd")) &&
                    <div className="calendar-dot-top bg-news" />
                }
                {eventsTopic?.PostDates?.map(x => (format(Date.parse(x), "yyyy-MM-dd"))).includes(format(day, "yyyy-MM-dd")) &&
                    <div className="calendar-dot-bottom bg-events" />
                }
                <span>{format(day, "d")}</span>
            </div>
        )
    }
    if (newsCategory == null) {
        return <div />
    }
    else {
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
                    <div key={postIndex} className="border-top py-3">
                        <div className="d-flex align-items-start pb-3">
                            <div className="h4 pe-2">
                                {post.Subject.Topic.Name == "Events" ? (
                                    <FontAwesomeIcon className="text-events" icon={faCalendar} />
                                ) : (
                                    <FontAwesomeIcon className="text-news" icon={faNewspaper} />
                                )}
                            </div>
                            <h4>{moment(post.EventDate != null ? post.EventDate : post.Time).format('YYYY/MM/DD')}</h4>
                        </div>
                        <div className="row py-2 ">
                            <div className="col-1" style={{ minWidth: 175 }}>
                                <div className="row m-0">
                                    <img className="profile-picture-rounded pb-2" src={`../Pictures/${post?.Aurthor.ProfilePicture?.Path}`}></img>
                                </div>
                                <div className="text-center text-primary" onClick={() => { history.push(`/user/${post.Aurthor.Id}`); }}>
                                    <h5><a>{post.Aurthor?.Name}</a></h5>
                                </div>
                            </div>
                            <div className="col" style={{ minWidth: 250 }, { minHeight: 100 }}>
                                <div className="bubble h-100 w-100 p-3">
                                    <button className="float-end btn btn-link" onClick={() => { history.push(`/post/${post.Id}`); }}>
                                        <FontAwesomeIcon className="text-primary h2" icon={faLocationArrow} />
                                    </button>
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
}