import React, { useState } from "react";
import OrderCreate from "./components/OrderCreate";
import OrderUpdate from "./components/OrderUpdate";
import { variables } from "./Variables.js";

export default function App() {
  const [orders, setOrders] = useState([]);
  const [showingCreateNewOrderForm, setShowingCreateNewOrderForm] =
    useState(false);
  const [orderCurrentlyBeingUpdated, setOrderCurrentlyBeingUpdated] =
    useState(null);

  function getOrders() {
    const url = variables.API_URL + "Orders/getAllOrders";

    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((ordersFromServer) => {
        setOrders(ordersFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function deleteOrder(Id) {
    const url = variables.API_URL + `Orders/deleteOrder?Id=${Id}`;

    fetch(url, {
      method: "DELETE",
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        onOrderDeleted(Id);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {showingCreateNewOrderForm === false &&
            orderCurrentlyBeingUpdated === null && (
              <div>
                <h1>Table Orders</h1>

                <div className="mt-5">
                  <button
                    onClick={getOrders}
                    className="btn btn-dark btn-lg w-100"
                  >
                    Get Orders from server
                  </button>
                  <button
                    onClick={() => setShowingCreateNewOrderForm(true)}
                    className="btn btn-secondary btn-lg w-100 mt-4"
                  >
                    Create New Order
                  </button>
                </div>
              </div>
            )}

          {orders.length > 0 &&
            showingCreateNewOrderForm === false &&
            orderCurrentlyBeingUpdated === null &&
            renderOrdersTable()}

          {showingCreateNewOrderForm && (
            <OrderCreate onOrderCreated={onOrderCreated} />
          )}

          {orderCurrentlyBeingUpdated !== null && (
            <OrderUpdate
              ord={orderCurrentlyBeingUpdated}
              onOrderUpdated={onOrderUpdated}
            />
          )}
        </div>
      </div>
    </div>
  );

  function renderOrdersTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Id (PK)</th>
              <th scope="col">SendCity</th>
              <th scope="col">SendStreet</th>
              <th scope="col">SendHome</th>
              <th scope="col">RecCity</th>
              <th scope="col">RecStreet</th>
              <th scope="col">RecHome</th>
              <th scope="col">Weight</th>
              <th scope="col">DatePickup</th>
              <th scope="col">Options</th>
            </tr>
          </thead>
          <tbody>
            {orders.map((ord) => (
              <tr key={ord.Id}>
                <th scope="row">{ord.Id}</th>
                <td>{ord.SendCity}</td>
                <td>{ord.SendStreet}</td>
                <td>{ord.SendHome}</td>
                <td>{ord.RecCity}</td>
                <td>{ord.RecStreet}</td>
                <td>{ord.RecHome}</td>
                <td>{ord.Weight}</td>
                <td>{ord.DatePickup}</td>
                <td>
                  <button
                    onClick={() => setOrderCurrentlyBeingUpdated(ord)}
                    className="btn btn-dark btn-lg mx-3 my-3"
                  >
                    Update
                  </button>
                  <button
                    onClick={() => {
                      if (
                        window.confirm(
                          `Are you sure you want to delete the order with id "${ord.Id}"?`
                        )
                      )
                        deleteOrder(ord.Id);
                    }}
                    className="btn btn-secondary btn-lg"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button
          onClick={() => setOrders([])}
          className="btn btn-dark btn-lg w-100"
        >
          Empty React orders array
        </button>
      </div>
    );
  }

  function onOrderCreated(createdOrder) {
    setShowingCreateNewOrderForm(false);

    if (createdOrder === null) {
      return;
    }

    alert(`Order successfully created.`);

    getOrders();
  }

  function onOrderUpdated(updatedOrder) {
    setOrderCurrentlyBeingUpdated(null);

    if (updatedOrder === null) {
      return;
    }

    let ordersCopy = [...orders];

    const index = ordersCopy.findIndex((ordersCopyOrder, currentIndex) => {
      if (ordersCopyOrder.Id === updatedOrder.Id) {
        return true;
      }
    });

    if (index !== -1) {
      ordersCopy[index] = updatedOrder;
    }

    setOrders(ordersCopy);

    alert(`Order successfully updated.`);

    getOrders();
  }

  function onOrderDeleted(deletedOrderId) {
    let ordersCopy = [...orders];

    const index = ordersCopy.findIndex((ordersCopyOrder, currentIndex) => {
      if (ordersCopyOrder.Id === deletedOrderId) {
        return true;
      }
    });

    if (index !== -1) {
      ordersCopy.splice(index, 1);
    }

    setOrders(ordersCopy);

    alert("Order successfully deleted.");
  }
}
