import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { InsumoComponent } from './components/insumo/insumo.component';
import { SidebarComponent } from "./layout/sidebar/sidebar.component";

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [RouterOutlet, InsumoComponent, SidebarComponent]
})
export class AppComponent {
  title = 'Controle Estoque';
}
