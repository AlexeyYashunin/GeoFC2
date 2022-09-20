import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Search, SearchType } from './Search';

export class SearchCity extends React.Component<RouteComponentProps<{}>, {}> {
    render() {
        return <div>
            <h1>Search by City</h1>
            <div>
                <Search searchUrl="city/locations?city=" searchType={SearchType.City}/>
            </div>
        </div>;
    }
};