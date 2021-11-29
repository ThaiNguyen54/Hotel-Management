import flask
from flask import request, jsonify, Response
import json
from flask_ngrok import run_with_ngrok
from flask_cors import CORS, cross_origin
import pandas as pd
import sqlite3
import constant as constant
import service as service
app = flask.Flask(__name__)
app.config["DEBUG"] = True
CORS(app)
run_with_ngrok(app)




@app.route('/item', methods=['POST'])
def add_item():
    # Get item from the POST body
    req_data = request.get_json()
    item = req_data['item']

    # Add item to the list
    res_data = service.add_to_list(item)

    # Return error if item not added
    if res_data is None:
        response = Response("{'error': 'Item not added - " + item + "'}", status=400 , mimetype='application/json')
        return response

    # Return response
    response = Response(json.dumps(res_data), mimetype='application/json')
    return response
@app.route('/item/', methods=['GET'])
def get_all_items():
    # Get items from the helper
    res_data = service.get_all_items()
    # Return response
    response = Response(json.dumps(res_data), mimetype='application/json')
    return response

@app.route('/item', methods=['PUT'])
def update_status():
    # Get item from the POST body
    req_data = request.get_json()
    item = req_data['item']
    status = req_data['status']

    # Update item in the list
    res_data = service.update_status(item, status)

    # Return error if the status could not be updated
    if res_data is None:
        response = Response("{'error': 'Error updating item - '" + item + ", " + status   +  "}", status=400 , mimetype='application/json')
        return response

    # Return response
    response = Response(json.dumps(res_data), mimetype='application/json')

    return response
@app.route('/item', methods=['DELETE'])
def delete_item():
    # Get item from the POST body
    req_data = request.get_json()
    item = req_data['item']
    # Delete item from the list
    res_data = service.delete_item(item)
    # Return error if the item could not be deleted
    if res_data is None:
        response = Response("{'error': 'Error deleting item - '" + item +  "}", status=400 , mimetype='application/json')
        return response
    # Return response
    response = Response(json.dumps(res_data), mimetype='application/json')

    return response
if __name__ == '__main__':
    app.run()
