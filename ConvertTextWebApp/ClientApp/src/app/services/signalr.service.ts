import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable, Subject } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection!: signalR.HubConnection; 
  private apiUrl = environment.apiUrl;
  private receivedMessageObject: Subject<string> = new Subject<string>();

  startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${this.apiUrl}/hub`, { withCredentials: true })
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR connection started'))
      .catch((err: any) => console.log('Error while starting connection...', err));

  }

  addReceivedMessageListener = () => {
    this.hubConnection.on('ReceiveMessage', (data: string) => {
      this.receivedMessageObject.next(data);
    });
  }

  getReceivedMessage = (): Observable<string> => {
    return this.receivedMessageObject.asObservable();
  }
}