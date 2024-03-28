import { DataTable } from "simple-datatables";
import { useEffect } from "react";
import { AddButton } from "../button/addItem";

export const TableAdmin = ({ btnDataAdd, handleSubmit, columns, data }) => {
  useEffect(() => {
    new DataTable("#datatablesSimple");
  });
  return (
    <div className="card mb-4">
      <div className="card-header">
        <i className="fas fa-table me-1"></i>
        DataTable Example{" "}
        <AddButton fields={btnDataAdd} handleSubmit={handleSubmit} />
      </div>
      <div className="card-body">
        <table id="datatablesSimple">
          <thead>
            <tr>
              {columns.map((column, index) => (
                <th key={"colum-table-" + index}>{column}</th>
              ))}
              <th className="text-center">Actions</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item, index) => (
              <tr key={"item-value-" + index}>
                {columns.map((column, index) => (
                  <td key={"colum-table-" + index}>{item[column]}</td>
                ))}
                <td className="text-center">
                  {" "}
                  <i className="fa fa-edit me-1" onClick={() => {}}></i>
                  <i className="fa fa-trash" onClick={() => {}}></i>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};
