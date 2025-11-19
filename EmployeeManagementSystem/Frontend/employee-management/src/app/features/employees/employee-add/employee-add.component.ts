import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../../../core/services/employee.service';

@Component({
  selector: 'app-employee-add',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent implements OnInit {

  employeeForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      id: ['', [Validators.required, Validators.min(1)]],
      name: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(1)]],
      department: ['', Validators.required]
    });
  }

  onSubmit(): void {

    console.log('Running');
    // if (this.employeeForm.invalid) {
    //   this.employeeForm.markAllAsTouched();
    //   return;
    //  }

    const emp = {
      id: Number(this.employeeForm.value.id),
      name: this.employeeForm.value.name,
      salary: this.employeeForm.value.salary,
      department: this.employeeForm.value.department
    };



     console.log("PAYLOAD SENDING TO API:", emp);

    this.employeeService.addEmployee(emp).subscribe({
      next: () => {
        alert('Employee added successfully!');
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error("Error adding employee:", err);

        if (err.error?.errors) {
          console.log("Validation errors:", err.error.errors);
        }

        alert("Failed to add employee.");
      }
    });
  }

}
