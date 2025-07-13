import axios from "axios";
import {
  createContext,
  useEffect,
  useReducer,
  type FC,
  type ReactNode,
} from "react";

interface Notification {
  id: string | number;
  message: string;
  // Add other fields as needed (e.g., createdAt, type, etc.)
}

// Define the state shape
interface NotificationState {
  notifications: Notification[];
}

type NotificationAction =
  | { type: "LOAD_NOTIFICATIONS"; payload: Notification[] }
  | { type: "DELETE_NOTIFICATION"; payload: Notification[] }
  | { type: "CLEAR_NOTIFICATIONS"; payload: Notification[] }
  | { type: "CREATE_NOTIFICATION"; payload: Notification[] };

// Define the context value shape
interface NotificationContextValue {
  notifications: Notification[];
  deleteNotification: (notificationID: string | number) => Promise<void>;
  clearNotifications: () => Promise<void>;
  getNotifications: () => Promise<void>;
  createNotification: (notification: Notification) => Promise<void>;
}

const initialState: NotificationState = {
  notifications: [],
};

const reducer = (
  state: NotificationState,
  action: NotificationAction
): NotificationState => {
  switch (action.type) {
    case "LOAD_NOTIFICATIONS": {
      return { ...state, notifications: action.payload };
    }
    case "DELETE_NOTIFICATION": {
      return { ...state, notifications: action.payload };
    }
    case "CLEAR_NOTIFICATIONS": {
      return { ...state, notifications: action.payload };
    }
    case "CREATE_NOTIFICATION": {
      return { ...state, notifications: action.payload };
    }
    default:
      return state;
  }
};

const NotificationContext = createContext<NotificationContextValue>({
  notifications: [],
  deleteNotification: async () => {},
  clearNotifications: async () => {},
  getNotifications: async () => {},
  createNotification: async () => {},
});

interface NotificationProviderProps {
  children: ReactNode;
}
// NotificationProvider component
export const NotificationProvider: FC<NotificationProviderProps> = ({
  children,
}) => {
  const [state, dispatch] = useReducer(reducer, initialState);

  const deleteNotification = async (notificationID: string | number) => {
    try {
      const res = await axios.post<{ data: Notification[] }>(
        "/api/notification/delete",
        {
          id: notificationID,
        }
      );
      dispatch({ type: "DELETE_NOTIFICATION", payload: res.data.data });
    } catch (e) {
      console.error(e);
    }
  };

  const clearNotifications = async () => {
    try {
      const res = await axios.post<{ data: Notification[] }>(
        "/api/notification/delete-all"
      );
      dispatch({ type: "CLEAR_NOTIFICATIONS", payload: res.data.data });
    } catch (e) {
      console.error(e);
    }
  };

  const getNotifications = async () => {
    try {
      const res = await axios.get<{ data: Notification[] }>(
        "/api/notification"
      );
      dispatch({ type: "LOAD_NOTIFICATIONS", payload: res.data.data });
    } catch (e) {
      console.error(e);
    }
  };

  const createNotification = async (notification: Notification) => {
    try {
      const res = await axios.post<{ data: Notification[] }>(
        "/api/notification/add",
        { notification }
      );
      dispatch({ type: "CREATE_NOTIFICATION", payload: res.data.data });
    } catch (e) {
      console.error(e);
    }
  };

  useEffect(() => {
    getNotifications();
  }, []);

  return (
    <NotificationContext.Provider
      value={{
        getNotifications,
        deleteNotification,
        clearNotifications,
        createNotification,
        notifications: state.notifications,
      }}
    >
      {children}
    </NotificationContext.Provider>
  );
};

export default NotificationContext;
