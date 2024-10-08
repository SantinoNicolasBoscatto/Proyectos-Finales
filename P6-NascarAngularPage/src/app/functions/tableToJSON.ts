export function tableToJson(table: HTMLTableElement): any[] {
    const data: any[] = [];
    const headers: string[] = [];
    
    for (let i = 0; i < table.rows[0].cells.length; i++) {
      headers[i] = table.rows[0].cells[i].innerHTML.toLowerCase().replace(/ /gi, '').replace(/↵/g, '');
      if (headers[i].includes("driver")) headers[i] = "Piloto";
      else if (headers[i].includes("pts")) headers[i] = "Puntos";
      else if (headers[i].includes("#")) headers[i] = "Numero";
      else headers[i] = headers[i].charAt(2).toUpperCase() + headers[i].slice(3);
    }
    
    for (let i = 1; i < table.rows.length; i++) {
      const tableRow = table.rows[i];
      const rowData: { [key: string]: string } = {};
      for (let j = 0; j < tableRow.cells.length; j++) {
        rowData[headers[j]] = tableRow.cells[j].innerHTML.replace('*', '');
      }
      data.push(rowData);
    }
    
    return data;
  }
  