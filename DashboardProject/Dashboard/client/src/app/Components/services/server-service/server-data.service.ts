import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServerDataService {

  constructor(private http: HttpClient) {  }


  public getServers() : Observable<any> {
    return this.http.get<any>("https://localhost:5001/api/servers");
  }

  public updateServerStatus(id: number, message: string) : Observable<any> {
    return this.http.put(`https://localhost:5001/api/servers/${id}`, {"payload": message});
  }
}
