import { Routes } from '@angular/router';

import { EmployeeListComponent } from './features/employees/employee-list/employee-list.component';
import { EmployeeAddComponent } from './features/employees/employee-add/employee-add.component';
import { EmployeeEditComponent } from './features/employees/employee-edit/employee-edit.component';

export const routes: Routes = [
  { path: '', component: EmployeeListComponent },
  { path: 'add', component: EmployeeAddComponent },
  { path: 'edit/:id', component: EmployeeEditComponent },

  //handles invalid URLs
  { path: '**', redirectTo: '' }
];
