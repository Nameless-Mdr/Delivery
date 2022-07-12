import React, { useState } from "react";
import { variables } from "../Variables.js";

export default function OrderCreate(props) {
  const initialFormData = Object.freeze({
    sendCity: "Kaliningrad",
    sendStreet: "Lenina",
    sendHome: 43,
    recCity: "Novosibirsk",
    recStreet: "Pishkina",
    recHome: 10,
    weight: 1000,
  });

  const [formData, setFormData] = useState(initialFormData);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const orderToCreate = {
      id: null,
      sendCity: formData.sendCity,
      sendStreet: formData.sendStreet,
      sendHome: formData.sendHome,
      recCity: formData.recCity,
      recStreet: formData.recStreet,
      recHome: formData.recHome,
      weight: formData.weight,
      datePickup: formData.datePickup,
    };

    const url = variables.API_URL + "Orders/insertOrder";

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(orderToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onOrderCreated(orderToCreate);
  };

  return (
    <form className="w-100 px-5">
      <h1 className="mt-5">Create new order</h1>

      <div className="mt-5">
        <label className="h3 form-label">Sender City</label>
        <input
          value={formData.sendCity}
          name="sendCity"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Sender Street</label>
        <input
          value={formData.sendStreet}
          name="sendStreet"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Sender Home</label>
        <input
          value={formData.sendHome}
          name="sendHome"
          type="number"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-5">
        <label className="h3 form-label">Recipient City</label>
        <input
          value={formData.recCity}
          name="recCity"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Recipient Street</label>
        <input
          value={formData.recStreet}
          name="recStreet"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Recipient Home</label>
        <input
          value={formData.recHome}
          name="recHome"
          type="number"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Package Weight</label>
        <input
          value={formData.weight}
          name="weight"
          type="number"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Date pickup</label>
        <input
          value={formData.datePickup}
          name="datePickup"
          type="date"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">
        Submit
      </button>
      <button
        onClick={() => props.onOrderCreated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </form>
  );
}
