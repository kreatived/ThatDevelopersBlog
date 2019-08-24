import React from 'react';

export const PopularPostsWidget = () => {

    return (
        <>
            <br/>
            <div className="card">
                <div className="card-header">
                    <h4>Popular Posts</h4>
                </div>
                <ul className="list-group">
                    <li className="list-group-item"><a href="#">Something about something</a></li>
                    <li className="list-group-item"><a href="#">Something about something else</a></li>
                    <li className="list-group-item"><a href="#">More about something</a></li>
                    <li className="list-group-item"><a href="#">Less about nothing</a></li>
                    <li className="list-group-item"><a href="#">The worst of the best</a></li>
                </ul>
            </div>
        </>
    )
}