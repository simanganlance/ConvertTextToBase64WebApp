import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { EncodingService } from './services/encoding.service';
import { SignalRService } from './services/signalr.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] // Use styleUrls for styles
})
export class AppComponent implements OnInit{
  title = 'ClientApp';
  encodingInProgress = false;
  encodedText = '';
  inputText: string = ''; 

  constructor(
    private encodingService: EncodingService,
    private signalRService: SignalRService
  ) {}
	
	ngOnInit() {
		this.signalRService.startConnection();
		this.signalRService.addReceivedMessageListener();
		this.signalRService.getReceivedMessage().subscribe((message: string) => {
		  // Handle the received message
		  this.encodedText += message;
		});
  }
  startEncoding() {
    if (this.encodingInProgress) {
      console.log('Encoding in progress. Cannot start another.');
      return;
    }

    if (!this.inputText) {
      console.log('Please enter text to encode.');
      return;
    }

    this.encodingInProgress = true;
    this.encodedText = '';

    this.encodingService.startEncoding(this.inputText).subscribe(
      () => {
		  // Reset button
		  this.encodingInProgress = false;
	  },
      (error) => {
        console.log('Error starting encoding:', error);
        this.encodingInProgress = false;
      }
    );
  }

  cancelEncoding() {
    this.encodingService.cancelEncoding().subscribe(
      () => {
        this.encodingInProgress = false;
      },
      (error) => {
        console.log('Error canceling encoding:', error);
      }
    );
  }
}
