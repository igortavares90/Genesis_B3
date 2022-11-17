import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CDB } from './cdb';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  error = new Subject<string>();

  constructor(private http: HttpClient) { }

  private readonly API = 'https://localhost:7143';

getCDB(InitialValue: number , NumberOfMonths: number) {
  return this.http.get<CDB>(`${ this.API }/CDB?InitialValue=${InitialValue}&NumberOfMonths=${NumberOfMonths}`);
  };
}

