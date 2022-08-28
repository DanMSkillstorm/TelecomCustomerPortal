import { Component, OnInit } from "@angular/core";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'stormer-mobile-angular';
  JoeImagePath: string;

  constructor () {
  this.JoeImagePath = 'src\assets\img\joeAndBro.png';
  }

  ngOnInit(): void {
    
  }
}
