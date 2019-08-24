import React from 'react';

export const CategoriesWidget = () => {

    return (
        <>
            <br/>
            <div className="card">
                <div className="card-header">
                    <h4>Categories</h4>
                </div>
                <ul className="list-group">
                    <li className="list-group-item"><a href="#">Code</a></li>
                    <li className="list-group-item"><a href="#">SEO</a></li>
                    <li className="list-group-item"><a href="#">Blog</a></li>
                    <li className="list-group-item"><a href="#">Teaching</a></li>
                </ul>
            </div>
        </>
    )
}