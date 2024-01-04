import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EncodingService {
  private apiUrl = environment.apiUrl;
  private baseUrl = `${this.apiUrl}/api/encode`; // Relative URL for API requests

  constructor(private http: HttpClient) {}

  startEncoding(input: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/start/${input}`);
  }

  cancelEncoding(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/cancel`);
  }
}