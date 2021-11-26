import { Component, OnInit } from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {AuthService} from "../shared/auth.service";
import {LoginDto} from "../shared/login.dto";

@Component({
  selector: 'app-EASV-CS20-FW-Assignment-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = this.fb.group({
    username:[''],
    password:['']
  })
  constructor(private fb:FormBuilder,
              private _auth: AuthService){}


  ngOnInit(): void {
  }

  login() {
    const loginDto = this.loginForm.value as LoginDto;
    this._auth.login(loginDto)
      .subscribe(token => {
        console.log('Token: ', token)
      })
    console.log('loginInfo: ', this.loginForm.value);
  }
}
