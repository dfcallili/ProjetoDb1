import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute} from '@angular/router';

@Component({
    selector: 'gituserdetail',
    templateUrl: './gituserdetail.component.html'
})
export class GitUserDetailComponent {
    public getUserDetail: GitUser;
    public getUserDetailRepos: GitUserRepo[];


    constructor(http: Http, @Inject('BASE_URL_GIT_API') baseUrl: string, route: ActivatedRoute) {
        route.params.subscribe(params => {

            console.log(params);
            if (params['id']) {
                //this.getUser(params['id']);
                var login = params['id'];
                http.get(baseUrl + 'users/' + login).subscribe(result => {
                    this.getUserDetail = result.json() as GitUser;
                }, error => console.error(error));

                http.get(baseUrl + 'users/' + login + '/repos').subscribe(result => {
                    this.getUserDetailRepos = result.json() as GitUserRepo[];
                }, error => console.error(error));
            }

        });
    }
}

interface GitUser {
    login: string;
    id: number;
    avatar_url: string;
    gravatar_id: string;
    url: string;
    html_url: string;
    followers_url: string;
    following_url: string;
    gists_url: string;
    starred_url: string;
    subscriptions_url: string;
    organizations_url: string;
    repos_url: string;
    events_url: string;
    received_events_url: string;
    type: string;
    site_admin: boolean;
}

interface GitUserRepo {
    "id": number;
    "name": string;
    "full_name": string;
    "private": boolean;
    "html_url": string;
}