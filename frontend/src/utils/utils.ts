import { differenceInSeconds } from "date-fns";

export const convertHexToRGB = (hex: string): string | undefined => {
  // Check if it's an rgba string
  if (hex.startsWith("rgba")) {
    const triplet = hex.slice(5).split(",").slice(0, -1).join(",");
    return triplet;
  }

  // Validate hex format (#RGB or #RRGGBB)
  if (/^#([A-Fa-f0-9]{3}){1,2}$/.test(hex)) {
    let c: string[] = hex.substring(1).split("");
    if (c.length === 3) {
      c = [c[0], c[0], c[1], c[1], c[2], c[2]];
    }
    const hexValue = "0x" + c.join("");
    const num = parseInt(hexValue, 16);

    return [(num >> 16) & 255, (num >> 8) & 255, num & 255].join(",");
  }

  // Return undefined for invalid input
  return undefined;
};

export function getTimeDifference(date: Date) {
  const difference = differenceInSeconds(new Date(), date);
  if (difference < 60) return `${Math.floor(difference)} sec`;
  else if (difference < 3600) return `${Math.floor(difference / 60)} min`;
  else if (difference < 86400) return `${Math.floor(difference / 3660)} h`;
  else if (difference < 86400 * 30)
    return `${Math.floor(difference / 86400)} d`;
  else if (difference < 86400 * 30 * 12)
    return `${Math.floor(difference / 86400 / 30)} mon`;
  else return `${(difference / 86400 / 30 / 12).toFixed(1)} y`;
}
