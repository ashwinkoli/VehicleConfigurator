import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';

export default function Display()
{
    const [pro, setPro] = useState({});
    const {code} = useParams();
    console.log(useParams());
    useEffect(()=>
    {
        fetch("https://localhost:7289/api/Products/"+code)
        .then(res=>res.json())
        .then((result) => {setPro(result)});
    }, []);
    return (
        <div>
        <Form.Label><b>Manufacture</b></Form.Label>
      <Form.Select>
        <option>Disabled select</option>
      </Form.Select>
      </div>
        // <div className="App App-header" color="Red">
        //     <table border="5" className='bg-text'>
        //         <thead background-color="green">
        //             <tr>
        //                 <th>
        //                     ProductID
        //                 </th>

        //                 <th>
        //                     ProductName
        //                 </th>

        //                 <th>
        //                     Category
        //                 </th>

        //                 <th>
        //                     Color
        //                 </th>

        //                 <th>
        //                     Unit Price
        //                 </th>

        //                 <th>
        //                     Available Quantity
        //                 </th>
        //             </tr>
        //         </thead>
        //         <tbody>
        //             <td>
        //                 {pro.productId}
        //             </td>

        //             <td>
        //                 {pro.name}
        //             </td>

        //             <td>
        //                 {pro.category}
        //             </td>

        //             <td>
        //                 {pro.color}
        //             </td>

        //             <td>
        //                 {pro.unitPrice}
        //             </td>

        //             <td>
        //                 {pro.availableQuantity}
        //             </td>
        //         </tbody>
        //     </table>
        // </div>
    );
}