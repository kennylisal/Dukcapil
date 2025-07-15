import { NavigationItemSimple } from "./navigation-item-simple/NavigationItemSimple";
import { NavigationItemNested } from "./navigation-item-nested/NavigationItemNested";
import { NavigationItemHeader } from "./navigation-item-header/NavigationItemHeader";
import type { NavigationItemType } from "./types";

interface Props {
  item: NavigationItemType;
}

export const NavigationItem = ({ item }: Props) => {
  const isSimple = "path" in item;
  const isHeader = "header" in item;

  if (isHeader) {
    return <NavigationItemHeader header={item.header} />;
  }

  return isSimple ? (
    <NavigationItemSimple item={item} />
  ) : (
    <NavigationItemNested item={item} />
  );
};
