import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Superpoderes } from '../models/superpoderes';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuperpoderesService {

  private url: string = 'https://localhost:7263/Superpoder';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    })
  };
  constructor(private http: HttpClient) { }

  ListarSuperpoderes(): Observable<Superpoderes[]> {
    return this.http.get<Superpoderes[]>(`${this.url}`, this.httpOptions)
  }
}