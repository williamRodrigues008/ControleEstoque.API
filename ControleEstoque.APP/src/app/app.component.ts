import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { InsumoComponent } from './components/insumo/insumo.component';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [RouterOutlet, InsumoComponent]
})
export class AppComponent {
  title = 'Controle Estoque';
}
