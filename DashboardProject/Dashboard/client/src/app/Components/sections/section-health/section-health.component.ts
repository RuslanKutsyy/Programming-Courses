import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Server } from '../../../shared/server';
import { ServerDataService } from '../../services/server-service/server-data.service';


@Component({
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})
export class SectionHealthComponent implements OnInit {

  servers: Server[];

  constructor(private srvSvc: ServerDataService) { 
    
  }

  ngOnInit(): void {
    this.srvSvc.getServers().subscribe(response => this.servers = response);
  }
}
