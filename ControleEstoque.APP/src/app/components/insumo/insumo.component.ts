import { Component } from '@angular/core';
import { Insumo } from '../../models/insumo.model';
import { InsumoService } from '../../core/services/insumo.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-insumo',
  standalone: true,
  templateUrl: './insumo.component.html',
  styleUrl: './insumo.component.css',
  imports: [CommonModule]
})

export class InsumoComponent {

  ngOnInit() {
    this.listarInsumos();
  }

  insumos$ = new Observable<Insumo[]>();

  constructor(private insumoService: InsumoService) {
    this.listarInsumos()
  }

  listarInsumos(){
    this.insumos$ = this.insumoService.getInsumos();
  }
}
