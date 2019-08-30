import React, {useEffect, useState} from 'react';

export const Comments = () => {

    useEffect(() => {

        const loadComments = async() => {
            try {
                const requestUrl = process.env.API_BASE_URL + 'posts/' + match.params.slug + '/comments?page=1';
                const response = await axios.get(requestUrl);
                updateComments(response.data.comments)
            }catch(error) {
                console.error(error);
            }
        };

        loadComments();

    }, [])

    return (
        <h1>Comments</h1>
    )
}