import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink],
  template: `
    <nav class="navbar navbar-expand navbar-dark bg-dark px-3">
      <a class="navbar-brand" routerLink="/">Employee Management</a>

      <div class="navbar-nav ms-auto">
        <a class="nav-link" routerLink="/">Home</a>
        <a class="nav-link" routerLink="/add">Add Employee</a>
        <!-- <a class="nav-link" [routerLink]="['/edit', employee.id]">Edit</a>
   -->
      </div>
    </nav>

    <div class="container mt-4">
      <router-outlet></router-outlet>
    </div>
  `,
  styleUrls: ['./app.css']
})
export class AppComponent {
  title = signal('Employee Management System');
}
