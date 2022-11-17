import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { CDB } from './cdb';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'CDB';
  error = new Subject<string>();


  constructor(private http : HttpClient, private service: AppService) {

  }

  model!: CDB;
  initialValue: number=0;
  numberOfMonths: number=0;

  ngOnInit(){

  }

  getCDB(): void {
  {
    this.service.getCDB(this.initialValue,this.numberOfMonths).subscribe((data) => {
      this.model = data;
    },(err) => {this.error.next(err)});
  }
  }
}