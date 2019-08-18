import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { PostSummary } from '../PostSummary';

export const Posts = () => {

    const [posts, updatePosts] = useState([]);
    useEffect(() => {

        const loadData = async () => {
            try {
                const response = await axios.get('https://localhost:5001/api/posts');
                updatePosts(response.data.posts);
            }catch(error) {
                console.error(error);
            }
        };

        loadData();
    }, []);

    return (
        <>
            <h1>Latest Posts</h1>
                {posts.length == 0 && <p>Loading posts...</p>}
                {
                    posts.length > 0 && posts.map(post => (
                        <PostSummary key={post.id} post={post} />
                    ))
                }
                <br/>
            <div className="row">
                <div className="col-md-6">
                    <a href="#">← Older</a>
                </div>
                <div className="col-md-6 text-right">
                    <a href="#">Newer →</a>
                </div>
            </div>
        </>
    )
}