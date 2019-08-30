import React from 'react';
import {BrowserRouter as Router, Route, Link} from 'react-router-dom';
import { Header } from '../Header';
import { Main } from '../Main';
import { Footer } from '../Footer';
import { NavBar } from '../NavBar';
import { Posts } from '../Posts';
import { Post } from '../Post';
import { SubscribeWidget } from '../widgets/SubscribeWidget';
import { PopularPostsWidget } from '../widgets/PopularPostsWidget';
import { CategoriesWidget } from '../widgets/CategoriesWidget';

export const App = () => {

    return (
        <Router>
            <div className="container">
                <Header>
                    <NavBar />
                </Header>
                <Main>
                    <div className="row">
                        <div className="col-md-8">
                            <Route path="/" exact component={Posts}/>
                            <Route path="/:slug" component={Post} />
                        </div>
                        <div className="col-md-4">
                            -- Sidebar Widgets --
                        </div>
                    </div>
                </Main>
                <Footer />
            </div>
        </Router>
    )
}