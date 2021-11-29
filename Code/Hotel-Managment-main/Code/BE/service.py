import sqlite3
import constant

def add_to_list(item):
    try:
        conn = sqlite3.connect(constant.DB_PATH)
        # Once a connection has been established, we use the cursor
        # object to execute queries
        c = conn.cursor()
        # Keep the initial status as Not Started
        c.execute('insert into ITEM(item, status) values(?,?)', (item, constant.NOTSTARTED))
        # We commit to save the change
        conn.commit()
        return {"item": item, "status": constant.NOTSTARTED}
    except Exception as e:
        print('Error: ', e)
        return None
def get_all_items():
    try:
        conn = sqlite3.connect(constant.DB_PATH)
        c = conn.cursor()
        c.execute('select * from ITEM')
        rows = c.fetchall()
        return { "count": len(rows), "items": rows }
    except Exception as e:
        print('Error: ', e)
        return None
def update_status(item, status):
    # Check if the passed status is a valid value
    if (status.lower().strip() == 'not started'):
        status = constant.NOTSTARTED
    elif (status.lower().strip() == 'completed'):
        status = constant.COMPLETED
    else:
        print("Invalid Status: " + status)
        return None

    try:
        conn = sqlite3.connect(constant.DB_PATH)
        c = conn.cursor()
        c.execute('update ITEM set status=? where item=?', (status, item))
        conn.commit()
        return {item: status}
    except Exception as e:
        print('Error: ', e)
        return None
def delete_item(item):
    try:
        conn = sqlite3.connect(constant.DB_PATH)
        c = conn.cursor()
        c.execute('delete from ITEM where item=?', (item,))
        conn.commit()
        return {'item': item}
    except Exception as e:
        print('Error: ', e)
        return None