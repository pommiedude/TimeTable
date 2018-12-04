import { Component, OnInit, Inject } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  private hubConnection: HubConnection;

  ngOnInit(): void {
  
    // this.hubConnection = new HubConnectionBuilder().withUrl('http://localhost:5000/schedules').build();
    // this.hubConnection
    //   .start()
    //   .then(() => console.log('Connection started!'))
    //   .catch(err => console.log('Error while establishing connection :('));

    // this.hubConnection.on('BroadcastMessage', (type: string, payload: string) => {
    //   debugger;
    //   console.log('type: ' + type + ', payload: ' + payload);
    //   // TODO: Update this.vm.schedules variable with the schedules received, or if
    //   // smaller transaction are used delete, add single components etc...
    // });
  }
}
