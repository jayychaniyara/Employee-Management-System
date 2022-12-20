import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public screenWidth: any;  
  public screenHeight: any;  
  title = 'management-system';

  ngOnInit() {  
    this.screenWidth = window.innerWidth;  
    this.screenHeight = window.innerHeight - 57;  
  }  

@HostListener('window:resize', ['$event'])  
  onResize(event:any) { 
    console.log(event); 
    this.screenWidth = window.innerWidth;  
    this.screenHeight = window.innerHeight - 57;  
  }  
}
