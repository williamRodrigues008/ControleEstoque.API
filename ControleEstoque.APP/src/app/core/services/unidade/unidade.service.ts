import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { unidade } from '../../../models/unidade.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UnidadeService {
  private url = environment.apiUrl;
  constructor(private http: HttpClient) {}

  buscarUnidades(): Observable<unidade[]> {
    return this.http.get<unidade[]>(`${this.url}/api/Unidade/ListarUnidades`);
  }
}
