import React from 'react';
import './PostSummary.css';
import Moment from 'react-moment';

export const PostSummary = (props) => {

    return (
        <article>
            <h2><a href="#">{props.post.title}</a></h2>

            <div className="row">
                <div className="group1 col-sm-6 col-md-6">
                    <span className="fas fa-folder-open mr-1"></span> <a href="#" className="mr-2">Category</a>
                    <span className="fas fa-bookmark mr-1"></span> <a href="#">Topic</a>
                </div>
                <div className="group2 col-sm-8 col-md-6">
                    <span className="fas fa-pencil-alt mr-1"></span><a href="#" className="mr-2">20 comments</a>
                    <span className="fas fa-clock mr-1"></span><Moment format="YYYY-MM-DD">{props.post.publicationDate}</Moment>
                </div>
            </div>

            <hr/>

            <img src="http://placehold.it/900X300" alt="placeholder" className="img-fluid"/>

            <br/>

            <p className="lead">{props.post.teaser}</p>

            <p className="text-right">
                <a href="#" className="text-right">
                    continue reading...
                </a>
            </p>
        </article>
    )
}