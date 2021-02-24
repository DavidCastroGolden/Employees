import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { employeeSalaries: [], loading: true, employeeId: '' };
  }

  componentDidMount() {
      this.populateEmployeeSalary();
  }

  static renderEmployeesTable(employeeSalaries) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>contractTypeName</th>
            <th>roleName</th>
            <th>roleDescription</th>
            <th>hourlySalary</th>
            <th>hourlyToAnualSalary</th>
            <th>monthlySalary</th>
            <th>montlyToAnualSalary</th>
          </tr>
        </thead>
        <tbody>
                {employeeSalaries.map(info =>
              <tr key={info.id}>
                  <td>{info.id}</td>
                        <td>{info.name}</td>
                        <td>{info.contractTypeName}</td>
                        <td>{info.roleName}</td>
                        <td>{info.roleDescription}</td>
                        <td>{info.hourlySalary}</td>
                        <td>{info.hourlyToAnualSalary}</td>
                        <td>{info.monthlySalary}</td>
                        <td>{info.montlyToAnualSalary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderEmployeesTable(this.state.employeeSalaries);

    return (
      <div>
        <h1 id="tabelLabel" >Employee Salary based on the contract type</h1>
        <p>This developer is looking for a new contract type</p>

        <input value={this.state.employeeId} onChange={event => this.setState({employeeId: event.target.value.replace(/\D/,'')})}/>
        <br/>
        <br/>
        <button className="btn btn-primary" onClick={() => this.populateEmployeeSalary()}>Search Employee(s)</button>
        {contents}
      </div>
    );
  }

  async populateEmployeeSalary() {

    console.log(this.state.employeeId);
    
    const response = await fetch(this.getUrl());
    const data = await response.json();
      this.setState({ employeeSalaries: data, loading: false });
    }

    getUrl() {
      if(this.state.employeeId != '')
      {
        return 'employee/' + this.state.employeeId;
      }else
      {
        return 'employee';
      }
    }

}
