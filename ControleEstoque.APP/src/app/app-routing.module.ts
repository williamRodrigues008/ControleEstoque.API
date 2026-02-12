import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InsumoComponent } from './components/insumo/insumo.component';
import { NotFoundError } from 'rxjs';

export const routes: Routes = [
  { path: 'home', component: InsumoComponent },
  { path: "insumos", component: InsumoComponent},
  { path: "quimicos", component: NotFoundError }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
