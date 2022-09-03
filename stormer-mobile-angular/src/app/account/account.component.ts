import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const WebAPI_ENDPOINT = 'https://graph.microsoft.com/v1/0/me';

//need to check schema
type AccountType = {
  givenName?: string,
  surname?: string,
  userPrincipalName?: string,
  id?: string
};

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  account!: AccountType;

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.getAccount();
  }

  getAccount() {
    this.http.get(WebAPI_ENDPOINT)
      .subscribe(account => {
        this.account = account;
      });
  }

  //update Account
}
