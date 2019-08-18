import React from 'react';
import { Header } from '../Header';
import { Main } from '../Main';
import { Footer } from '../Footer';
import { NavBar } from '../NavBar';
import { Posts } from '../Posts';
import { SubscribeWidget } from '../widgets/SubscribeWidget';
import { PopularPostsWidget } from '../widgets/PopularPostsWidget';
import { CategoriesWidget } from '../widgets/CategoriesWidget';

export const App = () => {

    return (
        <div className="container">
            <Header>
                <NavBar />
            </Header>
            <Main>
                <div className="row">
                    <div className="col-md-8">
                        <Posts />
                    </div>
                    <div className="col-md-4">
                        -- Sidebar Widgets --
                    </div>
                </div>
            </Main>
            <Footer />
        </div>
    )
}