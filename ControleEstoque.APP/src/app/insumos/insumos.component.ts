// insumo.component.ts
import { Component, OnInit } from '@angular/core';
import { Insumo } from './insumos.model';

@Component({
  selector: 'app-insumo',
  templateUrl: './insumo.component.html'
})
export class insumoComponent implements OnInit {

  insumos: Insumo[] = [];

  constructor(private insumoService: InsumoService) {}

  ngOnInit(): void {
    this.insumoService.listar().subscribe(dados => {
      this.insumos = dados;
    });
  }
}
