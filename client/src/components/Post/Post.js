import React, {useEffect, useState} from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import Moment from 'react-moment';

export const Post = ({match}) => {

    const [post, updatePost] = useState({});
    const [comments, updateComments] = useState({});
    useEffect(() => {

        const loadPost = async () => {
            try {
                const requestUrl = process.env.API_BASE_URL + 'posts/' + match.params.slug;
                const response = await axios.get(requestUrl);
                updatePost(response.data);
            }catch(error) {
                console.error(error);
            }
        };

        loadPost();
    }, []);

    return (
        <>
            <article>
            {post == undefined && <p>Loading post...</p>}
            {
                post != undefined &&
                <>
                    <h2>{post.title}</h2>

                    <div className="row">
                        <div className="group1 col-sm-6 col-md-6">
                            <span className="fas fa-folder-open mr-1"></span> <a href="#" className="mr-2">Category</a>
                            <span className="fas fa-bookmark mr-1"></span> <a href="#">Topic</a>
                        </div>
                        <div className="group2 col-sm-8 col-md-6">
                            <span className="fas fa-pencil-alt mr-1"></span><a href="#" className="mr-2">20 comments</a>
                            <span className="fas fa-clock mr-1"></span><Moment format="YYYY-MM-DD">{post.publicationDate}</Moment>
                        </div>
                    </div>

                    <hr/>

                    <img src="http://placehold.it/900X300" alt="placeholder" className="img-fluid"/>

                    <br/>

                    {post.content}
                </>
            }
                
            </article>

            <hr/>

            <div className="row">
                <div className="col-md-6">
                    <Link to="/">← Back to posts</Link>
                </div>
            </div>
        </>
    )
}