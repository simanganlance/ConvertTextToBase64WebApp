import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule if needed
import { EncodingService } from './services/encoding.service'; // Import EncodingService
import { SignalRService } from './services/signalr.service'; // Import SignalRService
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http'; 


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
	HttpClientModule
  ],
  providers: [
    EncodingService,
    SignalRService,
    // Other services or providers
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }