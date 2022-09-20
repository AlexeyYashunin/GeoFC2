import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Search, SearchType } from './Search';

export class SearchIP extends React.Component<RouteComponentProps<{}>, {}> {
    render() {
        return <div>
            <h1>Search by IP address</h1>
            <div>
                <Search searchUrl="ip/location?ip=" searchType={SearchType.IP}/>
            </div>
        </div>;
    }
};