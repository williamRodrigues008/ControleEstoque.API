import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { MatIcon, MatIconModule } from "@angular/material/icon";

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule, MatIcon, MatIconModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {

}
