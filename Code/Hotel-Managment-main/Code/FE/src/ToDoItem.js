import React from "react"

const TodoItem = (props) => {
    console.log(props)
    return (
        <div className="todo-item">
            <p>{props.item}</p>
            <input
                type="checkbox"
                defaultChecked={props.status === 'Completed' ? true : false}
                id="myCheck"
                onClick={() => { props.onUpdate() }}
            />
            <button onClick={() => { props.onDelete() }}>Delete</button>
        </div>
    )
}

export default TodoItem;