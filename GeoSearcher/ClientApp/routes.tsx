import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { SearchIP } from './components/SearchIP';
import { SearchCity } from './components/SearchCity';

export const routes = <Layout>
    <Route exact path='/' component={SearchIP} />
    <Route path='/city' component={SearchCity} />
</Layout>;
