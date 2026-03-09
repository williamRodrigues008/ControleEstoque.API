import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { local } from '../../models/local';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocalService {
  private url = environment.apiUrl;

  constructor(private http: HttpClient) { }

  buscarLocais()
  : Observable<local[]>
  {
    return this.http.get<local[]>(`${this.url}/api/Locais/ListarLocais`);
  }

}
