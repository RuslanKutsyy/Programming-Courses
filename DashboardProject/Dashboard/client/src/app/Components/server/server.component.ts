import { Component, OnInit, Input } from '@angular/core';
import { Server } from '../../shared/server';
import { ServerDataService } from '../services/server-service/server-data.service';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {

  constructor(private http: ServerDataService) { }

  color : string;
  buttonText: string;

  @Input() serverInput : Server;

  ngOnInit(): void {
    this.setServerStatus(this.serverInput.isOnline, this.serverInput.lastDownDate);
  }

  setServerStatus(isOnline: boolean, lastDownTimeDate: Date){
    if (isOnline){
      this.serverInput.isOnline = true;
      this.serverInput.lastDownDate = lastDownTimeDate;
      this.color = "#66BB6A";
      this.buttonText = "Shut Down";
    } else {
      this.serverInput.isOnline = false;
      this.serverInput.lastDownDate = lastDownTimeDate;
      this.color = "#FF6B6B";
      this.buttonText = "Start";
    }
  }

  toggleStatus(onlineStatus: boolean, id: number) : void {    
    let message = onlineStatus ? "deactivate" : "activate";
    this.http.updateServerStatus(id, message).toPromise().then((response => {
      let data = response as Server;
      this.setServerStatus(data.isOnline, data.lastDownDate)
    })).catch(console.error);
  }
}

