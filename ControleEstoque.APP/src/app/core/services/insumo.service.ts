import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Insumo } from '../../models/insumo.model';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InsumoService {

  private url = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getInsumos(){
    return this.http.get<Insumo[]>(`${this.url}/api/Insumos/listarInsumos`).pipe(
      map(ins => ins ?? [])
    )
  }
}
