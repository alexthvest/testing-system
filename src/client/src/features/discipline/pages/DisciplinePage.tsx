import React, { useEffect, useState } from "react";
import { fetchUser } from "../../../core/api/useUser.hook";
import { User } from "../../../core/models/user.model";

export const DisciplinePage: React.FC = () => {
  const [user, setUser] = useState<User>();

  useEffect(() => {
    fetchUser().then((user) => {
      setUser(user!);
    });
  }, []);

  return (
    <div>
      <h1 className="text-2xl text-black">
        {user?.firstName} {user?.lastName}
      </h1>
    </div>
  );
};
