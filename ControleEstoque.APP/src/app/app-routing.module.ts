import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InsumoComponent } from './components/insumo/insumo.component';
import { NotFoundError } from 'rxjs';
import { MovimentacaoComponent } from './components/movimentacao/movimentacao.component';

export const routes: Routes = [
  { path: 'home', component: MovimentacaoComponent },
  { path: "insumos", component: InsumoComponent},
  { path: "quimicos", component: NotFoundError }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
