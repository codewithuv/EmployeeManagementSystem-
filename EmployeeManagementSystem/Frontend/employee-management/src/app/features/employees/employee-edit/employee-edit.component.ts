import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../../../core/services/employee.service';
import { Employee } from '../../../core/models/employee.model';

@Component({
  selector: 'app-employee-edit',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {

  employeeForm!: FormGroup;
  employeeId!: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {

    // Create form with controls expected by backend
    this.employeeForm = this.fb.group({
      id: [{ value: '', disabled: true }], // show but not editable
      name: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(1)]],
      department: ['', Validators.required]
    });

    // Get employee id from route
    this.employeeId = Number(this.route.snapshot.paramMap.get('id'));

    // Load employee data
    this.employeeService.getEmployee(this.employeeId).subscribe(emp => {
      this.employeeForm.patchValue(emp);
    });
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {

      // include id manually because it's disabled in UI
      const updatedEmployee: Employee = {
        id: this.employeeId,
        ...this.employeeForm.getRawValue()
      };

      this.employeeService.updateEmployee(this.employeeId, updatedEmployee).subscribe({
        next: () => {
          alert('Employee updated successfully!');
          this.router.navigate(['/']);
        },
        error: err => {
          console.error(err);
          alert('Update failed! (Maybe 409 conflict)');
        }
      });
    }
  }
}
